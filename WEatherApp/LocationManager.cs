using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace WEatherApp
{
    public class LocationManager
    {
        public static GeolocationAccessStatus accessStatus;

        public async static Task<Geoposition> GetPosition()
        {
            var acccessStatus = await Geolocator.RequestAccessAsync();

            /*
            if (accessStatus != GeolocationAccessStatus.Allowed)
            {
                throw new Exception();
            }
            */

            var geolocator = new Geolocator { DesiredAccuracyInMeters = 0 };

            var positionN = await geolocator.GetGeopositionAsync();

            return positionN;
           

        }
    }
}
