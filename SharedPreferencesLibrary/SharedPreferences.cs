using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SharedPreferencesLibrary
{
    class SharedPreferences
    {
        private static SharedPreferences _instance = null;
        private Context _context = null;

        public static SharedPreferences GetInstace(Context context)
        {
            if (_instance == null)
            {
                _instance = new SharedPreferences(context);
            }
            return _instance;
        }

        private SharedPreferences(Context context)
        {
            _context = context;
        }
        private ISharedPreferences _getSharedPreferences()
        {
            var contextPref = _context.GetSharedPreferences
                ("defaultColl", FileCreationMode.Private);
            return contextPref;
        }

        public void SetPref(string key, string value)
        {
            
            var contextEdit = _getSharedPreferences().Edit();
            contextEdit.PutString(key, value);
            contextEdit.Commit();
        }

        public string GetPref(string key, string defaultValue)
        {
            _getSharedPreferences();
            return _getSharedPreferences().GetString(key, defaultValue);
        }

    }
}