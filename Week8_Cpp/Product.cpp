//
// Created by billy on 3/11/2022.
//

#include "Product.h"

#include <utility>
using namespace std;

Product::Product() {
    _prodName = "Unnamed Product";
    _price = 0.00;
    _quantity = 0;

}

Product::Product(string name, double price, int quantity)
        : _prodName(std::move(name)), _price(price), _quantity(quantity){

}

string Product::getName() {
    return _prodName;
}

double Product::getPrice() const {
    return _price;
}

int Product::getQuantity() const {
    return _quantity;
}

double Product::CalculatePrice() {
    return 0.1 * _price;
}

void Product::PrintDetails() {
    cout
            << "this is the base function" << endl;
}
