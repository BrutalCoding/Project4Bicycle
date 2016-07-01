﻿using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
using Xamarin.Forms.Maps;

namespace Project4Bicycle
{

	public class BikeContainerViewModel
	{
		public ObservableCollection<BikeContainer> BikeContainers { get; } = new ObservableCollection<BikeContainer>();


		public async Task GetHaltesAsync()
		{
			//RetDatabase database = new RetDatabase();

			BikeContainerDatabase database = new BikeContainerDatabase();

			//			Reset database
			//			database.Drop();


			if (database.Count())
			{
				string requestUri = "http://puu.sh/pxxc2.csv";
				var client = new HttpClient();
				var responseStream = await client.GetStreamAsync(requestUri);
				var reader = new StreamReader(responseStream);
				bool first = true;
				double latitude = 0f;
				double longtitude = 0f;



				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');
					if (!first)
					{
						string id = values[0];
						string description = values[5]; //fietstrommel
						string street = values[9];

						if (values[18] != "") { 
							latitude = Convert.ToDouble(values[18]); 
						}else {
							latitude = 0f;
						}

						if (values[19] != "")
						{
							longtitude = Convert.ToDouble(values[19]);
						}
						else {
							longtitude = 0f;
						}
						
						//double longtitude = Convert.ToDouble(values[19]);
						string neighbourhood = values[28];

						//if (longtitude != 0 && latitude != 0)
						//{


							//var position = new Position(latitude, longtitude);
							//var pin = new Pin
							//{
							//	Type = PinType.Place,
							//	Position = position,
							//	Label = description,
							//	Address = street
							//};


						BikeContainer bikeContainer = new BikeContainer();
						bikeContainer.ID = id;
						bikeContainer.Description = description;
						bikeContainer.Street = street;
						bikeContainer.Neighbourhood = neighbourhood;
						bikeContainer.Latitude = latitude;
						bikeContainer.Longitude = longtitude;

						database.SaveItem(bikeContainer);
						BikeContainers.Add(bikeContainer);
						//}
					}
					else {
						first = false;
					}
				}
			}
			else {
				foreach (var container in database.GetItems())
				{
					BikeContainers.Add(container);
				}
				
			}
		}
	}
}

