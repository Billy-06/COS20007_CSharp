#include <iostream>
#include "Order.h"
#include "Electrical.h"
#include "Sports.h"

int main()
{
    Order *order = new Order();
    Sports *sport = new Sports("One Hour", 20, 2, "Badminton");
    Electrical *elec = new Electrical("Device", 100, 1, 200);

    order->AddProduct(sport);
    order->AddProduct(elec);
    order->PrintOrders();

    system("pause");
    return 0;
}
