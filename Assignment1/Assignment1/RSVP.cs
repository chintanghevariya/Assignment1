using System;
namespace Assignment1
{
    class RSVP
    {
        private string date;
        private int id;
        private Event e;
        private Customer customer;
        private bool accepted = false;

        public RSVP(int id, string date, Event e, Customer c)
        {
            this.id = id;
            this.date = date;
            this.e = e;
            this.customer = c;
        }

        public string getDate() { return date; }
        public int getId() { return id; }
        public Event getEvent() { return e; }
        public Customer getCustomer() { return customer; }
        public void setAccepted(bool status) { accepted = status; }
        public bool getAccepted() { return accepted; }
    }
}
