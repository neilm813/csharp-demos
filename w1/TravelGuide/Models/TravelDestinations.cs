using System.Collections.Generic;

namespace TravelGuide.Models
{
    static public class TravelDestinations
    {
        static public List<Destination> Destinations { get; set; } = new List<Destination>()
        {
            new Destination("Longyearbyen", "https://en.visitsvalbard.com/imageresizer/?image=%2Fdmsimgs%2FE600D47425B2C241EB591A284DDE5C21ECC31B67.jpg&action=ProductDetailProFullWidth&crop=4D037D0DBBC22CD55D8AF767F9"),
            new Destination("Solovetsky Islands", "https://i.dailymail.co.uk/i/pix/2013/11/04/article-2487290-192FC96800000578-337_964x610.jpg"),
            new Destination("Socotra", "https://i.redd.it/fzpdoqe3zgn41.jpg"),
            new Destination("Bhutan", "https://www.adventurewomen.com/wp-content/uploads/2018/04/1.-Tigers-Nest-800x533.jpg"),
            new Destination("Hormuz Island", "https://i.pinimg.com/originals/7b/5d/fe/7b5dfe78e7a86eb2808c200973a46a83.jpg"),
            new Destination("Giant Crystal Cave", "https://cdn.tourismontheedge.com/wp-content/uploads/2013/01/Naica.Mine_.jpg"),
            new Destination("Hell", "https://i.guim.co.uk/img/static/sys-images/Guardian/Pix/pictures/2014/7/17/1405616925070/e1c101a3-2d79-4c22-869b-d65473479e5d-2060x1373.jpeg?width=940&quality=85&auto=format&fit=max&s=ba7e6537b8b4eba098f852088fe7c27d"),
            new Destination("Bed", "https://img-9gag-fun.9cache.com/photo/arovENB_460s.jpg")
        };
    }
}