using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Collections.Specialized;
using System.Collections;

namespace SURFFeature
{
    public class ModelImage
    {
        ImageFeature imageFeatures;
        int threshold;

        public int Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }

        public ImageFeature ImageFeatures
        {
            get { return imageFeatures; }
            set { imageFeatures = value; }
        }
        
    }
}
