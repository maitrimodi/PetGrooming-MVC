﻿using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
        {
            //what data do we need?
            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();
            return View(myspecies);
        }

        // Show
        // Add
        // [HttpPost] Add
        // Update
        // [HttpPost] Update
        // (optional) delete
        // [HttpPost] Delete

        //URL:/Species/Add
        //GOTO Views -> Species -> Add.csHtml
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string SpeciesName)
        {
            //STEP 1:GETHER USER INPUT DATA FOR PET SPECIES
            /*Debug.WriteLine("I am gathering species name of " +SpeciesName);*/
            //STEP2: CREATE QUERY
            string query = "insert into species (Name) values (@SpeciesName)";
            SqlParameter sqlparam = new SqlParameter("@SpeciesName",SpeciesName);
            //STEP3: RUN QUERY
            db.Database.ExecuteSqlCommand(query,sqlparam);
            //STEP4: GO BACK TO LIST OF SPECIES
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            string query = "delete from species where speciesid=@id";
            SqlParameter sqlparam = new SqlParameter("@id",id);

            db.Database.ExecuteSqlCommand(query, sqlparam);
            return RedirectToAction("List");
        }

        public ActionResult Show(int id)
        {
            //what information we need from the database to make showspeceis work?
            string query = "select * from species where speciesid = @id";
            SqlParameter sqlparam = new SqlParameter("@id",id);
            Species selectedspecies = db.Species.SqlQuery(query, sqlparam).FirstOrDefault();

            return View(selectedspecies);
        }

        public ActionResult Update(int id)
        {
            string query = "select * from species where speciesid = @id";
            SqlParameter sqlparam = new SqlParameter("@id",id);
            Species selectedspecies = db.Species.SqlQuery(query, sqlparam).FirstOrDefault();
            return View(selectedspecies);
        }

        [HttpPost]
        public ActionResult Update(int id, string SpeciesName)
        {
            string query = "update species set Name=@SpeciesName where speciesid = @id";
            SqlParameter[] sqlparams = new SqlParameter[2];//two items
            sqlparams[0] = new SqlParameter("@SpeciesName",SpeciesName);
            sqlparams[1] = new SqlParameter("@id",id);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");

        }
    }
}