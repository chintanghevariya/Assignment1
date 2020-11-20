using System;

namespace Assignment1
{
    class Event
    {
        private int eventId;
        private string eventName;
        private string venue;
        private Date eventDate;
        private int maxAttendees;
        private int numAttendees;
        private string dateCreated;
        private Customer[] attendeeList;
        private int numRsvps;
        private RSVP[] rsvps;

        public Event(int eventId, string name, string venue, Date eventDate, int maxAttendees)
        {
            this.eventId = eventId;
            this.eventName = name;
            this.venue = venue;
            this.eventDate = eventDate;
            this.maxAttendees = maxAttendees;
            numAttendees = 0;
            attendeeList = new Customer[maxAttendees];
            dateCreated = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            rsvps = new RSVP[maxAttendees];
        }

        public int getEventId() { return eventId; }
        public string getEventName() { return eventName; }
        public string getVenue() { return venue; }
        public Date getDate() { return eventDate; }

        public int getMaxAttendees() { return maxAttendees; }
        public int getNumAttendees() { return numAttendees; }

        public bool addRsvp(Customer c)
        {
            RSVP rsvp = new RSVP(numRsvps + 1, DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"), this, c);
            rsvps[numRsvps] = rsvp;
            numRsvps++;
            return true;
        }

        public string getRsvps()
        {
            string s = "RSVPs for this event: \n";

            for (int i = 0; i < numRsvps; i++)
            {
                s += rsvps[i].getDate() + " ";
                s += rsvps[i].getCustomer().getFirstName() + " ";
                s += rsvps[i].getCustomer().getLastName() + " \n";
            }

            return s;
        }

        public bool addAttendee(Customer c)
        {
            if (numAttendees >= maxAttendees) { return false; }
            attendeeList[numAttendees] = c;
            numAttendees++;
            return true;
        }

        private int findAttendee(int custId)
        {
            for (int x = 0; x < maxAttendees; x++)
            {
                if (attendeeList[x].getId() == custId)
                    return x;
            }
            return -1;
        }

        public bool removeAttendee(int custId)
        {
            int loc = findAttendee(custId);
            if (loc == -1) return false;
            attendeeList[loc] = attendeeList[numAttendees - 1];
            numAttendees--;
            return true;
        }

        public string getAttendees()
        {
            string s = "\nCustomers registered :";
            for (int x = 0; x < numAttendees; x++)
            {
                s = s + "\n" + attendeeList[x].getFirstName() + " " + attendeeList[x].getLastName();
            }
            return s;
        }

        public override string ToString()
        {
            string s = "Event: " + eventId + "\nName: " + eventName;
            s = s + "\nVenue: " + venue;
            s = s + "\nDate:" + eventDate;
            s = s + "\nRegistered Attendees:" + numAttendees;
            s = s + "\nAvailable spaces:" + (maxAttendees - numAttendees);
            s = s + getAttendees();
            return s;
        }

    }
}