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
				
		private bool ValidInput (CZAnimal animal, bool editingExisting)
		{
			// basic sensible input checks
			if (animal.Name.Trim ().Length == 0) {
				ModelState.AddModelError ("Name", "Please add a name!");
			}
			if (animal.Position.GetType () != typeof(int) ||
				animal.Position < 1 ||
				animal.Position > 12) {				
				ModelState.AddModelError (
					"Position",
					"The position should be an integer 0 < x < 13."
				);
			}			
			if (animal.Year.GetType () != typeof(int)) {
				ModelState.AddModelError ("Year", "The year should be an integer.");
			}
			
			// checking against the database
			
			// database matches
			var db = new ChiZodiacDb ("chinesezodiac.db");
			var names = db.Animals.Where<CZAnimal> (x => x.Name == animal.Name).ToList ();
			var positions = db.Animals.Where<CZAnimal> (x => x.Position == animal.Position)
				.ToList ();
			var years = db.Animals.Where<CZAnimal> (x => x.Year == animal.Year).ToList ();			
						
			if (names.Count > 0 && (!editingExisting || (editingExisting && names [0].Id != animal.Id))) {
				ModelState.AddModelError (
					"Name",
					string.Format ("This animal is already in the database.")
				);
			}			
			if (positions.Count > 0 && (!editingExisting || (editingExisting && positions [0].Id != animal.Id))) {
				ModelState.AddModelError (
					"Position",
					String.Format ("This position already has an animal (the {0}).", positions [0].Name
				)
				);
			}
			if (years.Count > 0 && (!editingExisting || (editingExisting && years [0].Id != animal.Id))) {
				ModelState.AddModelError (
					"Year",
					String.Format (
					"This year already has an animal (the {0}).",
					years [0].Name
				)
				);
			}
			
			return ModelState.IsValid;
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
			if (ValidInput (animal, false)) {
				var db = new ChiZodiacDb ("chinesezodiac.db");			
				db.Add (animal);
				// show some kind of confirmation
				return RedirectToAction (
					"Details",
					"Animals", new {
					name = animal.Name, position = animal.Position, year = animal.Year }
				);
			} else {
				return View (animal);	
			}			
		}
		
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Delete (int aid)
		{
			// it would be polite and sensible to have a confirmation page first
			var db = new ChiZodiacDb ("chinesezodiac.db");
			var animals = from a in db.Animals where a.Id == aid select a;
			foreach (var a in animals) {
				db.Delete (a);
			}
			return Redirect ("All");
		}
		
		[AcceptVerbs(HttpVerbs.Get)]
		public ActionResult Edit (int id)
		{
			var db = new ChiZodiacDb ("chinesezodiac.db");
			var an = (from a in db.Animals where a.Id == id select a).Single ();
			// didn't check for failure... DANGER!
			return View (an);
		}
		
		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Edit (CZAnimal animal)
		{
			/// Here we validate.
			if (ValidInput (animal, true)) {
				// call some command on the database
				var db = new ChiZodiacDb ("chinesezodiac.db");
				db.Update (animal);
				// show some kind of confirmation
				return RedirectToAction (
					"Details",
					"Animals", new {
					name = animal.Name, position = animal.Position, year = animal.Year }
				);
			} else {
				return View (animal);	
			}					
		}
		
	}
}

