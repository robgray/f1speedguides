using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BusinessLogic;
using umbraco.cms.businesslogic.web;

namespace atomicf1
{
    public class DriverDocument
    {
        private Document _document;

        public DriverDocument(Document document)
        {
            _document = document;
        }

        public string FavouriteTracks
        {
            get { return GetProperty<string>("favouriteTracks"); }
            set { SetProperty("favouriteTracks", value);}
        }


        public string DislikedTracks
        {
            get { return GetProperty<string>("dislikedTracks"); }
            set { SetProperty("dislikedTracks", value); }
        }

        public int DriverId
        {
            get { return GetProperty<int>("driverId"); }
            set { SetProperty("driverId", value); }
        }

        public int SpeedRating
        {
            get { return GetProperty<int>("speedRating"); }
            set { SetProperty("speedRating", value); }
        }   

        public int RacecraftRating
        {
            get { return GetProperty<int>("racecraftRating"); }
            set { SetProperty("racecraftRating", value); }
        }

        public string F1GuardianAngel
        {
            get { return GetProperty<string>("f1GuardianAngel"); }
            set { SetProperty("f1GuardianAngel", value); }
        }

        public string Summary
        {
            get { return GetProperty<string>("summary"); }
            set { SetProperty("summary", value); }
        }

        public string PCSpec
        {
            get { return GetProperty<string>("pCSpec"); }
            set { SetProperty("pCSpec", value); }
        }

        public string ControllerMethod
        {
            get { return GetProperty<string>("controllerMethod"); }
            set { SetProperty("controllerMethod", value); }
        }

        public string RacingView
        {
            get { return GetProperty<string>("racingView"); }
            set { SetProperty("racingView", value); }
        }

        public string About
        {
            get { return GetProperty<string>("bodyText"); }
            set { SetProperty("bodyText", value); }
        }

        protected T GetProperty<T>(string alias)
        {
            if (_document.getProperty(alias) != null)
                return (T) _document.getProperty(alias).Value;
            return default(T);
        }

        protected void SetProperty(string alias, object value)
        {
            var property = _document.getProperty(alias);
            if (property == null) return;
            property.Value = value;
        }

        public void Save()
        {
            _document.Save();            
            _document.Publish(User.GetAllByLoginName("robg", false).First());
            umbraco.library.UpdateDocumentCache(_document.Id);
        }
        
    }
}