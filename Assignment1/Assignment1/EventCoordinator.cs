using System;

namespace Assignment1
{
    class EventCoordinator
    {
        CustomerManager custMan;
        EventManager eventMan;

        public EventCoordinator(int custIdSeed, int maxCust, int eventIdSeed, int maxEvents)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            eventMan = new EventManager(eventIdSeed, maxEvents);
        }

        public bool addCustomer(string fname, string lname, string phone)
        {
            return custMan.addCustomer(fname, lname, phone);
        }

        public string customerList()
        {
            return custMan.getCustomerList();
        }

        public string getCustomerInfoById(int id)
        {
            return custMan.getCustomerInfo(id);
        }

        public bool deleteCustomer(int id)
        {
            return custMan.deleteCustomer(id);
        }

        public bool addEvent(string name, string venue, Date eventDate, int maxAttendee)
        {
            return eventMan.addEvent(name, venue, eventDate, maxAttendee);
        }

        public string eventList()
        {
            return eventMan.getEventList();
        }

        public string getEventInfoById(int id)
        {
            return eventMan.getEventInfo(id);
        }

        public bool addRsvp(int eventId, int customerId)
        {
            Customer customer = custMan.getCustomer(customerId);
            return eventMan.addRsvpForEvent(eventId, customer);
        }

        public string getRsvps()
        {
            return eventMan.getRsvps();
        }
    }
}
