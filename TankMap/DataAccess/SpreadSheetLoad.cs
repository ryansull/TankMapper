using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankMap.CSVMapping;
using TankMap.Models;
using FileHelpers;

namespace TankMap.DataAccess
{
    public class SpreadSheetLoad
    {
        public List<Tank> GetTanks()
        {
            var path = GetPathToSpreadSheet();
            var tanks = new List<Tank>();

            var engine = new FileHelperEngine(typeof(TankMapping)); 
            TankMapping[] res = engine.ReadFile(path) as TankMapping[];

            for (var i = 0; i < res.Length; i++)
            {
                tanks.Add(new Tank(res[i].Organization, res[i].TankInfo, res[i].TankName, res[i].TankAddress, res[i].City, res[i].State, res[i].Zip, res[i].TaskType, res[i].TaskStatus, res[i].FullAddress, res[i].Latitude, res[i].Longitude, i));
            }

            return tanks;
        }

        public void LoadTanks(IRepository<Tank> repo)
        {
            var tanks = GetTanks();

            foreach (var tank in tanks)
            {
                var existing = repo.SingleOrDefault(t => String.Compare(t.FullAddress,tank.FullAddress, true) == 0);
                if (existing == null)
                {
                    tank.ID = 0;
                    repo.Save(tank);
                }
            }
        }

        public string GetPathToSpreadSheet()
        {
            return "C:\\Code\\TankMap\\tanks.csv";
        }
    }
}