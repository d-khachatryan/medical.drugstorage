using Medicaldrugstore.DAL;
using System.Web.Mvc;

namespace Medicaldrugstore.Controllers
{
    public class FileController : Controller
    {
        private readonly StoreContext db = new StoreContext();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.DrugPictures.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}