﻿using System;
using Android.OS;
using Android.Provider;
using Android.Content;

using Xamarin.Forms;
using Java.Util;
using Android.Net;

[assembly: Dependency(typeof(Project4Bicycle.Droid.CalendarAPI))]

namespace Project4Bicycle.Droid
{
	public class CalendarAPI : ICalendar
	{
		public void SetEvent(DateTime date, string title, string note)
		{
			ContentValues eventValues = new ContentValues();
			eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, 1);
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Title, title);
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Description, note);
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS(date.Year, date.Month, date.Day, date.Hour, date.Minute));
			eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS(date.Year, date.Month, date.Day, date.Hour, date.AddMinutes(30).Minute));

			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
			eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");

			//Android.Content.ContentResolver.insert
			var uri = Forms.Context.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
			var id = uri.LastPathSegment;
		}

		public void SetReminder(string title)
		{
			//var calendarsUri = CalendarContract.Calendars.ContentUri;

			//string[] calendarsProjection = {
			//	CalendarContract.Calendars.InterfaceConsts.Id,
			//	CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
			//	CalendarContract.Calendars.InterfaceConsts.AccountName
			//};

			//var cursor = Forms.Context.ContentResolver.Query(calendarsUri, calendarsProjection, null, null, null);



			//Console.WriteLine(cursor.MoveToFirst());
			//Console.WriteLine(cursor.Count);
			//Console.WriteLine(cursor.GetString(1));
			//Console.WriteLine(cursor.GetString(2));
			//Console.WriteLine(cursor.MoveToNext());
			//Console.WriteLine(cursor.GetString(1));
			//Console.WriteLine(cursor.GetString(2));
			//Console.WriteLine(cursor.GetString(3));


			Console.WriteLine(title);
		}

		long GetDateTimeMS(int yr, int month, int day, int hr, int min)
		{
			Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

			c.Set(Calendar.DayOfMonth, day);
			c.Set(Calendar.HourOfDay, hr);
			c.Set(Calendar.Minute, min);
			c.Set(Calendar.Month, month);
			c.Set(Calendar.Year, yr);

			return c.TimeInMillis;
		}
	}
}

