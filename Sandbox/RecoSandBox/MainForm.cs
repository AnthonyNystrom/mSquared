using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.IO;

namespace SURFFeature
{  
    public partial class MainForm : Form
    {
        String modelFilesDirectory = null;
        String observedFile = null;

        List<Features2DTracker> modelFeatureTracker = new List<Features2DTracker>();
        List<string> modelImageFilePath = new List<string>();

        private bool modelImageDirSelected = false;
        private bool observedImageSelected = false;
        private bool initRequired = true;


        SURFDetector surfParam = new SURFDetector(350, false);

        Color defaultBackColor = Color.Transparent;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadModelImage_Click(object sender, EventArgs e)
        {
            DialogResult res = modelFolderDialog.ShowDialog();
            if (res != DialogResult.OK)
                return;

            LoadImages(modelFolderDialog.SelectedPath);
            modelFilesDirectory = modelFolderDialog.SelectedPath;

            modelImageDirSelected = true;

            if (modelImageDirSelected && observedImageSelected)
                btnStart.Enabled = true;

            initRequired = true;
        }

        private void LoadImages(string Path)        
        {
            
            string[] files = System.IO.Directory.GetFiles(Path);

            foreach (string file in files)
            {
                try
                {
                    Bitmap b = new Bitmap(file);
                    PictureBox p = new PictureBox();
                    p.Padding = new Padding(5);
                    p.Image = b;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Tag = file;                    
                    pnlModelImages.Controls.Add(p);

                }
                catch { }
                
            }
        }

        private void modelPictureBox_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlModelImages.Controls)
            {
                ((PictureBox)c).BorderStyle = BorderStyle.None;
                ((PictureBox)c).BackColor = defaultBackColor;
            }

            ((PictureBox)sender).BorderStyle = BorderStyle.Fixed3D;
            ((PictureBox)sender).BackColor = Color.SteelBlue;

            Image<Gray, Byte> res = (Image<Gray, Byte>)((PictureBox)sender).Tag;

            frmShowKeyPoints form = new frmShowKeyPoints(res.Bitmap);            
            form.ShowDialog();
        
        }

        private void btnSelectObservedImage_Click(object sender, EventArgs e)
        {
            DialogResult res = observedOpenFileDialog.ShowDialog();

            if (res != DialogResult.OK)
                return;

            observedFile = observedOpenFileDialog.FileName;

            Bitmap b = new Bitmap(observedFile);
            picBoxObserved.Image = b;


            observedImageSelected = true;

            if (modelImageDirSelected && observedImageSelected)
                btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            pnlMatchedImages.Controls.Clear();
            InitializeModels(modelFilesDirectory);
            StartDetection(observedFile);
        }

        private void InitializeModels(string modelImageDirPath)
        {
            string []files = Directory.GetFiles(modelFilesDirectory);

            progressBar.Minimum = 0;
            progressBar.Maximum = files.Length * 2;
            progressBar.Value = 0;

            foreach (string file in files)
            {
                if (initRequired)
                {
                    Image<Gray, Byte> modelImage = new Image<Gray, byte>(file);
                    ImageFeature[] modelFeatures = surfParam.DetectFeatures(modelImage, null);
                    Features2DTracker tracker = new Features2DTracker(modelFeatures);

                    modelFeatureTracker.Add(tracker);
                    modelImageFilePath.Add(file);
                }

                progressBar.Increment(1);
            }

            initRequired = false;
        }


        private void StartDetection(string observedImagePath)
        {   
            Image<Gray, Byte> observedImage = new Image<Gray, byte>(observedImagePath);

            Stopwatch watch = Stopwatch.StartNew();

            // Load input Image
            // extract features from the observed image
            ImageFeature[] imageFeatures = surfParam.DetectFeatures(observedImage, null);

            for(int i=0; i < modelFeatureTracker.Count; i++ )                
            {
                Features2DTracker tracker = modelFeatureTracker[i];
                    
                Features2DTracker.MatchedImageFeature[] matchedFeatures = tracker.MatchFeature(imageFeatures, 2, 20);
                matchedFeatures = Features2DTracker.VoteForUniqueness(matchedFeatures, 0.3);
                matchedFeatures = Features2DTracker.VoteForSizeAndOrientation(matchedFeatures, 1.5, 20);


                HomographyMatrix homography = Features2DTracker.GetHomographyMatrixFromMatchedFeatures(matchedFeatures);

                if( homography != null )
                {
                    try
                    {
                        string file = modelImageFilePath[i];
                        Bitmap b = new Bitmap(file);
                        PictureBox p = new PictureBox();
                        p.Padding = new Padding(5);
                        p.Size = new Size(100, 100);
                        p.Image = b;
                        p.SizeMode = PictureBoxSizeMode.AutoSize;
                        p.Tag = file;
                        p.Click += modelPictureBox_Click;
                        pnlMatchedImages.Controls.Add(p);                        

                        #region draw lines between the matched features
                        Image<Gray, Byte> modelImage = new Image<Gray, Byte>(file);
                        //Merge the object image and the observed image into one image for display
                        Image<Gray, Byte> res = modelImage.ConcateVertical(observedImage);
                        foreach (Features2DTracker.MatchedImageFeature matchedFeature in matchedFeatures)
                        {
                            PointF p1 = matchedFeature.ObservedFeature.KeyPoint.Point;
                            p1.Y += modelImage.Height;
                            PointF p2 = matchedFeature.SimilarFeatures[0].Feature.KeyPoint.Point;

                            res.Draw(new LineSegment2DF(p2, p1), new Gray(0), 1);
                        }
                        #endregion

                        #region draw the project region on the image
                        if (homography != null)
                        {
                            //draw a rectangle along the projected model
                            Rectangle rect = modelImage.ROI;
                            PointF[] pts = new PointF[] { 
                           new PointF(rect.Left, rect.Bottom),
                           new PointF(rect.Right, rect.Bottom),
                           new PointF(rect.Right, rect.Top),
                           new PointF(rect.Left, rect.Top)};
                            homography.ProjectPoints(pts);

                            for (int j = 0; j < pts.Length; j++)
                                pts[j].Y += modelImage.Height;

                            res.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Gray(255.0), 5);
                        }
                        #endregion

                        p.Tag = res;


                    }
                    catch { }

                    progressBar.Increment(1);
                }

            }

            progressBar.Hide();
            watch.Stop();
        }
    }
}
