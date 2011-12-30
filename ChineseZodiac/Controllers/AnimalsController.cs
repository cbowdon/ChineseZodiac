using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace ChineseZodiac
{
	public class AnimalsController : Controller
	{
		public ActionResult Index ()
		{
			return View ();
		}
		
		/// <summary>
		/// Show all the animals in the SQLite3 database
		/// </summary>
		public ActionResult All ()
		{
			var db = new ChiZodiacDb ("chinesezodiac.db");
			return View (db);
		}
		
		/// <summary>
		/// Details the Animal with the specified name.
		/// This is a GET action.
		/// So the URL is /Animals/Details?name={name}.
		/// </summary>
		/// <param name='name'>
		/// Name.
		/// </param>
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Details (string name, int position, int year)
		{
			name = name.ToLower ();
			// get db
			var db = new ChiZodiacDb ("chinesezodiac.db");
			// find animal in db
			var an = (from a in db.Animals 
			          where a.Name.ToLower () == name 
			          && a.Position == position
			          && a.Year == year
			          select a).Single ();
			// didn't check for failure... DANGER!
			return View (an);
		}
		
		/// <summary>
		/// The page with the empty form for adding an animal
		/// </summary>
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Create ()
		{
			return View ();
		}
		
		/// <summary>
		/// Handle submitted forms
		/// </summary>
		/// <param name='animal'>
		/// Animal.
		/// </param>
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Create (CZAnimal animal)
		{
			/// Here we validate.
			if (animal.Name.Trim ().Length == 0
			    // should also check that it's not a duplicate
			    ) {
				ModelState.AddModelError ("Name", "Please add a name!");
			}
			if (animal.Position.GetType () != typeof(int) ||
			// should add a check for position-too-high here
			    animal.Position < 1) {
				ModelState.AddModelError ("Position", "The position should be a positive integer.");
			}
			if (animal.Year.GetType () != typeof(int)) {
				ModelState.AddModelError ("Year", "The year should be an integer.");
			}
			
			
			if (ModelState.IsValid) {
				// call some command on the database
				var db = new ChiZodiacDb ("chinesezodiac.db");
				db.Add (animal);
				// show some kind of confirmation
				return RedirectToAction ("Details", "Animals", new { name = animal.Name });
			} else {
				return View (animal);	
			}			
		}
		
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Delete (string name)
		{
			// it would be polite and sensible to have a confirmation page first
			var db = new ChiZodiacDb ("chinesezodiac.db");
			var animals = from a in db.Animals where a.Name.ToLower () == name.ToLower () select a;
			foreach (var a in animals) {
				db.Delete (a);
			}
			return Redirect ("All");
		}
		
	}
}

