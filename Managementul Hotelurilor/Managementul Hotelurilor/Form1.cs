﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Managementul_Hotelurilor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void B_Reset_Click(object sender, EventArgs e)
        {
            comboBox_city.Items.Clear();
            comboBox_city.Enabled = false;

            comboBox_Country.Items.Clear();
            comboBox_Country.Enabled = false;
            b_Hotels.Enabled = true;


            comboBox_Hotels.Items.Clear();
            comboBox_Hotels.Enabled = false;

            availeble_Rooms_gridView.Enabled = false;
            availeble_Rooms_gridView.DataSource = null;
        }
        private void ComboBox_city_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox_Hotels.Enabled = true;
            comboBox_Hotels.Sorted = true;
            comboBox_Hotels.Items.Clear();

            int ID = DAL.Dal_Locations.GetLocationID(comboBox_city.Text, DAL.GlobalDictionary.LocationDictionary);

            DAL.DAL_Hotels hotels = new DAL.DAL_Hotels(ID);

            foreach (string s in hotels.HotelsDictionary.Values)
            {
                comboBox_Hotels.Items.Add(s);
            }
            DAL.GlobalDictionary.HotelsDictionary = hotels.HotelsDictionary;
            //TO DO: Punere Hoteluri dintr-un oras intr-un combobox pentru hoteluri
        }
        private void ComboBox_Country_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox_city.Enabled = true;
            comboBox_city.Sorted = true;
            comboBox_city.Items.Clear();

            int ID = DAL.Dal_Countries.GetCountryID(comboBox_Country.Text);

            DAL.Dal_Locations Locatii = new DAL.Dal_Locations(ID);
            foreach (string s in Locatii.LocationDictionary.Values)
            {
                comboBox_city.Items.Add(s);
            }
            DAL.GlobalDictionary.LocationDictionary = Locatii.LocationDictionary;
            //TO DO: ADD Elements from Location in a Combobox for location
        }

        private void B_Hotels_Click(object sender, EventArgs e)
        {
            comboBox_Country.Enabled = true;
            comboBox_Country.Sorted = true;
            comboBox_Country.Items.Clear();
            b_Hotels.Enabled = false;

            foreach (string s in DAL.Dal_Countries.CountriesDictionary.Values)
            {
                comboBox_Country.Items.Add(s);
            }
            //SOLVED: ADD  ELEMENTS FROM COUNTRY TABLE IN A COMBOBOX
        }

        private void ComboBox_Hotels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
