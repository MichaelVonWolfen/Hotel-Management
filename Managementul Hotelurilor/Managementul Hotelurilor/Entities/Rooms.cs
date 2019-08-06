﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Managementul_Hotelurilor.Entities
{
    class Rooms
    {
        public int Room_ID { get; }
        public string Room_Name { get; }
        public string FamilyType{ get; }
        public string Status { get; }
        public int Hotel_ID { get; }

        public Rooms(int Room_ID,string Room_Name, string FamilyType, string Status, int Hotel_ID)
        {
            this.Room_ID = Room_ID;
            this.Room_Name = Room_Name;
            this.FamilyType = FamilyType;
            this.Status = Status;
            this.Hotel_ID = Hotel_ID;
        }
        public Rooms(OracleDataReader reader)
        {
            Room_ID = Int32.Parse(reader["Room_ID"].ToString());
            Room_Name = reader["Room_Name"].ToString();
            FamilyType = reader["FamilyType"].ToString();
            Status = reader["Status"].ToString();
            Hotel_ID = Int32.Parse(reader["Hotel_ID"].ToString());
        }
    }
}
