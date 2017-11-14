
/******************************************************************************
 * This class uses the math.net numerics DenseMatrix class to implement 2D
 * affine transforms.
 * 
 * See https://en.wikipedia.org/wiki/Transformation_matrix#Affine_transformations
 ******************************************************************************/

using System;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Globalization;

namespace LitePlacer
{
    public class AffineTransform
    {
        public static FormMain MainForm;
        // Creates a point in the format that a transform will operate on
        public class Point
        {
            public Point(double X, double Y)
            {
                ptMatrix = new DenseMatrix(3, 1);
                ptMatrix[0, 0] = X;
                ptMatrix[1, 0] = Y;
                ptMatrix[2, 0] = 1;
            }
            public Point() : this(0,0)
            {
            }


            public double getX()
            {
                return ptMatrix[0, 0];
            }

            public double getY()
            {
                return ptMatrix[1, 0];
            }

            public static void display(Point[] pts)
            {
                for(int i = 0; i < pts.Length; i++)
                {
                    MainForm.DisplayText(" Point: " + i.ToString() +
                        " X: " + pts[i].getX().ToString("0.000", CultureInfo.InvariantCulture) +
                    " Y: " + pts[i].getY().ToString("0.000", CultureInfo.InvariantCulture));
            }
        }

            public DenseMatrix ptMatrix;
        }


        public AffineTransform()
        {
            theMatrix = DenseMatrix.CreateIdentity(3);
        }

        private DenseMatrix theMatrix;

        public static AffineTransform Identity()
        {
            return new AffineTransform();
        }

        public static AffineTransform getScaleInstance(double X, double Y)
        {
            AffineTransform retAT = new AffineTransform();
            retAT.theMatrix[0, 0] = X;
            retAT.theMatrix[1, 1] = Y;
            return retAT;
        }

        public static AffineTransform getTranslateInstance(double X, double Y)
        {
            AffineTransform retAT = new AffineTransform();
            retAT.theMatrix[0, 2] = X;
            retAT.theMatrix[1, 2] = Y;
            return retAT;
        }

        public static AffineTransform getRotateRadiansInstance(double ang)
        {
            AffineTransform retAT = new AffineTransform();
            double SinFactor = Math.Sin(ang);
            double CosFactor = Math.Cos(ang);
            retAT.theMatrix[0, 0] = CosFactor;
            retAT.theMatrix[0, 1] = SinFactor;
            retAT.theMatrix[1, 0] = -SinFactor;
            retAT.theMatrix[1, 1] = CosFactor;
            return retAT;
        }

        public static AffineTransform getRotateDegreesInstance(double ang)
        {
            return getRotateRadiansInstance(ang * Math.PI / 180);
        }

        public static AffineTransform getShearInstance(double X, double Y)
        {
            AffineTransform retAT = new AffineTransform();
            retAT.theMatrix[0, 1] = X;
            retAT.theMatrix[1, 0] = Y;
            return retAT;
        }

        public Point transformPoint(Point aPoint)
        {
            Point retPoint = new Point();
            //            aPoint.ptMatrix.Multiply(theMatrix, retPoint.ptMatrix);
            theMatrix.Multiply(aPoint.ptMatrix, retPoint.ptMatrix);
            return retPoint;
        }

        public void append(AffineTransform anAT)
        {
            theMatrix.Multiply(anAT.theMatrix, theMatrix);
        }

        public void preAppend(AffineTransform anAT)
        {
            anAT.theMatrix.Multiply(theMatrix, theMatrix);
        }

        public Point[] transformPoints(Point[] somePoints)
        {
            Point[] retPoints = new Point[somePoints.Length];
            for(int i=0; i < somePoints.Length; i++)
            {
                //MainForm.DisplayText("X : " + somePoints[i].getX().ToString() + " Y : " + somePoints[i].getY().ToString());
                retPoints[i] = transformPoint(somePoints[i]);
            }
            return retPoints;
        }

        // This is a little tricky, we don't want to change this instance
        // so we create a new one, change it and return it
        public AffineTransform inverse()
        {
            AffineTransform retAT = new AffineTransform();
            retAT.theMatrix = (DenseMatrix)theMatrix.Inverse();
            return retAT;
        }
    }
}
