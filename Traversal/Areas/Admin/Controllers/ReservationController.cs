using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _reservationService.GetListReservationWithDestination();
            return View(values);
        }
        public IActionResult Approve(int id)
        {
            Context context = new Context();
            var values = context.Reservations.Find(id);
            values.Status = "Onaylandı";
            context.Update(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Reject(int id)
        {
            var reservation = _reservationService.TGetByID(id);
            reservation.Status = "Reddedildi";
            _reservationService.TUpdate(reservation);
            return RedirectToAction("Index");
        }
    }
}
