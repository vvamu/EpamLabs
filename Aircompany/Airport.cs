using Aircompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aircompany.Planes;

namespace Aircompany
{
    public class Airport
    {
        private readonly List<Plane> _planes;


        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity
        {
            get
            {
                List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
                return passengerPlanes.Aggregate((w, x) => w.PassengersCapacity > x.PassengersCapacity ? w : x);
            }//??           
        }

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes() //todo
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();

            for (int i=0; i < _planes.Count; i++)
            {
                if (_planes[i] is PassengerPlane passengerPlane)
                {
                    passengerPlanes.Add(passengerPlane);
                        
                }
            }
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < _planes.Count; i++)
            {
                if (_planes[i].GetType() == typeof(MilitaryPlane))
                {
                    militaryPlanes.Add((MilitaryPlane)_planes[i]);
                }
            }
            return militaryPlanes;
        }



        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            for (int i = 0; i < militaryPlanes.Count; i++)
            {
                MilitaryPlane plane = militaryPlanes[i];
                if (plane.Type == MilitaryType.TRANSPORT)
                {
                    transportMilitaryPlanes.Add(plane);
                }
            }

            return transportMilitaryPlanes;
        }
        public Airport SortByMaxDistance()
        {
            return new Airport(_planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(w => w.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(w => w.MaxLoadCapacity));
        }

        public IEnumerable<Plane> GetAllPlanes()
        {
            return _planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", _planes.Select(x => x.Model)) +
                    '}';
        }
    }
}
