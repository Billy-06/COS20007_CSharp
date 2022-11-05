//
// Created by billy on 3/11/2022.
//

#ifndef WEEK8_CPP_PRODUCT_H
#define WEEK8_CPP_PRODUCT_H


#include <iostream>
#include <string>
using namespace std;

class Product {

private:
    string _prodName;
    double _price;
    int _quantity;

public:
    Product();
    Product(string name, double price, int quantity);
    double getPrice() const;
    string getName();
    int getQuantity() const;

    virtual double CalculatePrice();
    virtual void PrintDetails();
};

#endif //WEEK8_CPP_PRODUCT_H
