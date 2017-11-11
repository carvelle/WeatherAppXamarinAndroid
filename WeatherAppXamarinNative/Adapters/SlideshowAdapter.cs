using System;
using Android.Content;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

namespace WeatherAppXamarinNative
{
	public class SlideshowAdapter : PagerAdapter
	{
		BitmapHelper bitmapHelper;
		Context mContext;
		LayoutInflater mLayoutInflater;

		public SlideshowAdapter(Context context)
		{
			mContext = context;
			mLayoutInflater = (LayoutInflater)mContext.GetSystemService(Context.LayoutInflaterService);
		}

		public override int Count
		{
			get
			{
				return BackgroundImageSource.mResources.Length;	
			}
		}

		public override bool IsViewFromObject(View view, Java.Lang.Object @object)
		{
			return view == (@object);
		}

		public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
		{
			View itemView = mLayoutInflater.Inflate(Resource.Layout.image_view_layout, container, false);
			ImageView imageView = itemView.FindViewById<ImageView>(Resource.Id.background_image);
			imageView.SetImageBitmap(BitmapHelper.decodeBitmapFromResource(mContext.Resources, BackgroundImageSource.mResources[position], 640, 480));
            container.AddView(itemView);
            return itemView;
		}

		public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
		{
			container.RemoveView((LinearLayout) @object);
		}
	}
}
