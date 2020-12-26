﻿using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
//            var title = "Korona günlerinde arabalı sinema keyfi";
//            var content = string.Format(" İzmir Büyükşehir Belediyesi, 15 Mayıs Cuma günü açık havada sinema gösterimi yapacak. Altı noktada eş zamanlı"
//+ " olarak 'Bayi Toplantısı' filminin gösterileceği etkinlikte vatandaşlara maske dağıtılacak ve gösterimin yapılacağı"
//+ " alanda yurttaşların araçlarından inmelerine izin verilmeyecek. "
//+ " Koronavirüs önlemleri nedeniyle sinemaya gidemeyen İzmirliler, İzmir Büyükşehir Belediyesinin düzenlediği"
//+ " nostaljik arabalı sinema etkinliğinde buluşacak. Film gösterimi 15 Mayıs Cuma günü altı noktada eş zamanlı"
//+ " yapılacak. Bostanlı, Üçkuyular, Fuar İzmir, Bornova Aşık Veysel Rekreasyon Alanı Buz Pisti yanı, Buca ve Çiğli’de"
//+ "kurulacak dev perdede yönetmenliğini Bedran Güzel'in yaptığı 'Bayi Toplantısı' filmi ücretsiz gösterilecek. "
//+ "Sinemaseverler arabalarından inmeden güvenli bir şekilde sinema keyfi yaşayacak. Başrollerini İbrahim Büyükak,"
//+ "Onur Buldu, Doğu Demirkol'un paylaştığı, mecburen katıldıkları bayi toplantısında kendilerini birbirinden eğlenceli"
//+ "maceraların içinde bulan üç beyaz eşya satıcısının hikayesini konu eden film 21.00'da başlayacak. Filmin sesi radyo"
//+ "frekansı üzerinden arabalardan dinlenebilecek. 2 saat sürecek film gösterimi sırasında izleyicilere patlamış mısır ve"
//+ "gazoz da ikram edilecek. "
//+ "Kayıtlar 11 Mayıs'ta başlıyor. "
//+ "Belirli sayıda otomobilin girişine izin verilecek etkinliğe katılmak isteyen İzmirliler 11 Mayıs Pazar akşamı saat"
//+ "21.00'dan itibaren www.arabalisinema.com.tr adresinden kayıt yaptırması gerekiyor. Kayıt yaptıran ilk 750 araç"
//+ "sahibi etkinliğe katılım hakkı kazanacak. İstenilen bölgedeki arabalı sinema etkinliğinin kontenjanın dolması halinde"
//+ "katılımcılar kendilerine en yakın bölgedeki arabalı sinema etkinliğine yönlendirilecek. Etkinlik günü katılım hakkı"
//+ "kazanmış ve listeye alınmış kişilerin araçlarıyla arabalı sinema etkinliğinin yapıldığı alana girişine izin verilecek."
//+ "Gösterimin yapıldığı alana girdikten sonra vatandaşların araçlardan çıkılmasına izin verilmeyecek. ");

//            var news = new News(title, content);
//            news.CreateSummary();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
