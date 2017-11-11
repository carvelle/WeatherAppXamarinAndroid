using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace WeatherAppXamarinNative
{
    public class TypefaceTextView :TextView
    {
		protected TypefaceTextView(IntPtr javaReference, JniHandleOwnership transfer) 
       		 : base(javaReference, transfer){}

		public TypefaceTextView(Context context)
		: this(context, null) { }

		public TypefaceTextView(Context context, IAttributeSet attrs)
		: this(context, attrs, 0) { }
        	
		public TypefaceTextView(Context context, IAttributeSet attrs, int defStyle) 
        	: base(context, attrs, defStyle)
    	{
			var a = context.ObtainStyledAttributes(attrs, Resource.Styleable.TypefaceTextView);
			var customFont = a.GetString(Resource.Styleable.TypefaceTextView_typeface);
			SetCustomFont(customFont);
			a.Recycle();
		}

		public void SetCustomFont(string asset)
		{
			Typeface tf;
			try
			{
				tf = Typeface.CreateFromAsset(Context.Assets, asset);
			}
			catch (Exception e)
			{
				Log.Error("Textview", string.Format("Error: {1} , Typeface: {0} Could not be found ", asset, e));
				return;
			}

			if (tf == null) return;

			var tfStyle = TypefaceStyle.Normal;
			if (Typeface != null) 
				tfStyle = Typeface.Style;
				SetTypeface(tf, tfStyle) ;
		 }
	}
}