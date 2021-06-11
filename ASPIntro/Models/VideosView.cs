using System.Collections.Generic;

namespace ASPIntro.Models
{
    /* 
    Creating a class like this to represent the ViewModel is needed when you
    want to pass multiple types of data into the view all through the ViewModel.

    Add a prop for each kind of data you want to pass to the view.

    Alternatively, you can mix and match ViewModel for one type of data and
    put the other data in the ViewBag.
    */
    public class VideosView
    {
        public List<string> YoutubeVideoIds { get; set; }
        public int RandomNumber { get; set; }
    }
}