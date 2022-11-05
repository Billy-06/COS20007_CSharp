//
// Created by billy on 3/11/2022.
//

#include "Electrical.h"

Electrical::Electrical(): Product(){
    _watt = 0;
}

Electrical::Electrical(string name, double price, int quantity, int watt)
        : Product(name, price, quantity), _watt(watt){

}

double Electrical::CalculatePrice() {
    return 0.2 * Product::getPrice();
}

void Electrical::PrintDetails(){
    cout
    << "Name: " << Product::getName() << "\n"
    << "Price: " << Product::getPrice() << "\n"
    << "Quantity: " << Product::getQuantity() << "\n"
    << "Watts: " << _watt << "\n"
    << endl;
}
