//
// Created by billy on 3/11/2022.
//


#include "Sports.h"

using namespace std;

Sports::Sports() : Product() {

}

Sports::Sports(string name, double price, int quantity, string sportsType)
        : Product(name, price, quantity), _sportType(std::move(sportsType)){

}

double Sports::CalculatePrice() {
    return 0.5 * Product::getPrice();
}

void Sports::PrintDetails() {
    cout
    << "Name: " << Product::getName() << "\n"
    << "Price: " << Product::getPrice() << "\n"
    << "Quantity: " << Product::getQuantity() << "\n"
    << "Sports Type: " << _sportType << "\n"
    << endl;
}
