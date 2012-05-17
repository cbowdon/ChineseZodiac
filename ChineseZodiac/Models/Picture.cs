using System;
using System.Drawing;
using System.Web;
using System.Web.Mvc;

namespace ChineseZodiac
{
	public class ImageModel
	{
		public Image image;
		public HttpPostedFileWrapper upload { get; set; }
    	public string ImageName { get; set; } 
	
		public ImageModel (Image image, string name)
		{
			this.image = image;
			ImageName = name;	
		}

	}
}

