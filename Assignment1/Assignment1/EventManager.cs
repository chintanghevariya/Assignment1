using System;

namespace Assignment1
{
    class EventManager
    {
        private static int currentEventId;
        private int maxEvents;
        private int numEvents;
        private Event[] eventList;

        public EventManager(int idSeed, int max)
        {
            currentEventId = idSeed;
            maxEvents = max;
            numEvents = 0;
            eventList = new Event[maxEvents];
        }

        public bool addEvent(string name, string venue, Date eventDate, int maxAttendees)
        {
            if (numEvents >= maxEvents) { return false; }
            if (locationIsBooked(venue, eventDate)) { return false; }
            Event e = new Event(currentEventId, name, venue, eventDate, maxAttendees);
            eventList[numEvents] = e;
            numEvents++;
            currentEventId++;
            return true;
        }

        public bool addRsvpForEvent(int eventId, Customer customer)
        {
            if (customer == null) { return false; }
            Event e = getEvent(eventId);
            if (e.getNumAttendees() == e.getMaxAttendees()) { return false; }
            e.addRsvp(customer);
            return true;
        }

        private int findEvent(int eid)
        {
            for (int x = 0; x < numEvents; x++)
            {
                if (eventList[x].getEventId() == eid)
                    return x;
            }
            return -1;
        }

        public bool eventExists(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            return true;
        }

        public Event getEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return null; }
            return eventList[loc];
        }

        public bool locationIsBooked(string location, Date date)
        {
            bool found = false;

            for (int i = 0; i < numEvents; i++)
            {
                if (eventList[i].getVenue() == location && eventList[i].getDate().ToString() == date.ToString())
                {
                    found = true;
                }
            }

            return found;
        }

        public bool deleteEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            eventList[loc] = eventList[numEvents - 1];
            numEvents--;
            return true;
        }
        public string getEventInfo(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return "There is no event with id " + eid + "."; }
            return eventList[loc].ToString();
        }
        public string getEventList()
        {
            string s = "Event List:";
            for (int x = 0; x < numEvents; x++)
            {
                s = s + "\n" + eventList[x].getEventId() + " \t " + eventList[x].getEventName() + " \t " + eventList[x].getVenue();
            }
            return s;
        }

        public string getRsvps()
        {
            string s = "";

            for (int i = 0; i < numEvents; i++)
            {
                s += eventList[i].getRsvps();
            }

            return s;
        }

    }

}
