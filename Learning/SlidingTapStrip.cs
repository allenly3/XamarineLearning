using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Learning
{
   public class SlidingTapStrip: LinearLayout
    {
        ///--===========================---------------
        private const int DEFAULT_BOTTOM_BORDER_THICKNESS_DIPS = 2;
        private const byte DEFAULT_BOTTOM_BORDER_COLOR_ALPHA = 0X26;
        private const int SELECTED_INDICATOR_THICKNESS_DIPS = 8;
        private int[] INDICATOR_COLORS = { 0x19A319,0x0000FC};
        private int[] DIVIDER_COLORS = { 0xC5C5C5 };

        private const int DEFAULT_DIVIDER_THICKNESS_DIPS = 1;
        private const float DEFAULT_DIVIDER_HEIGHT = 0.5f;

        // Bottom border
        private int mBottomBorderThickness;
        private Paint mBottomBorderPaint;
        private int mDefaultBottomBorderColor;

        //indicator
        private int mSelectedIndicatorThickness;
        private Paint mSelectedIndicatorPaint;

        //Divider
        private Paint mDividerPaint;
        private float mDividerHeight;

        //Selected position and offset
        private int mSelectedPostion;
        private float mSelectedOffset;

        //Tab colorizer
        private SlidingTabScrollView.TabColorizer mCustomTabColorizer;
        private SimpleTabColorizer mDefaultTabColorizer;

        ///--------------------------
        // constructor
        public SlidingTapStrip(Context context) :this (context , null)
        {

        }

        public SlidingTapStrip (Context context, IAttributeSet attrs):base(context, attrs)
        {
            SetWillNotDraw(false);
            float density = Resources.DisplayMetrics.Density;

            TypedValue outValue = new TypedValue();

            context.Theme.ResolveAttribute(Android.Resource.Attribute.ColorForeground, outValue, true);

            int themeForeGround = outValue.Data;

            mDefaultBottomBorderColor = SetColorAlpha(themeForeGround, DEFAULT_BOTTOM_BORDER_COLOR_ALPHA);

            mDefaultTabColorizer = new SimpleTabColorizer();
            mDefaultTabColorizer.IndicatorColors=INDICATOR_COLORS;
            mDefaultTabColorizer.DividerColors=DIVIDER_COLORS;



        }

        private int SetColorAlpha(int themeForeGround, byte dEFAULT_BOTTOM_BORDER_COLOR_ALPHA)
        {
            throw new NotImplementedException();
        }



        private class SimpleTabColorizer : SlidingTabScrollView.TabColorizer
        {
            private int[] mIndicatorColors;
            private int[] mDividerColors;

            public int GetIndicatorColors(int position)
            {
                return mIndicatorColors[position % mIndicatorColors.Length];
            }

            public int GetDividerColors(int position)
            {
                return mDividerColors[position % mDividerColors.Length];
            }


            public int[] IndicatorColors
            {
                set { mIndicatorColors = value; }
            }

            public int[] DividerColors
            {
                set { mDividerColors = value; }
            }

        }
    }
}