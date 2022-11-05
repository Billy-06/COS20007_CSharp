//
// Created by billy on 3/11/2022.
//

#ifndef WEEK8_CPP_ELECTRICAL_H
#define WEEK8_CPP_ELECTRICAL_H


#include "Product.h"
#include <iostream>
#include <string>

using namespace std;

class Electrical : public Product {

private:
    int _watt;
public:
    Electrical();
    Electrical(string name, double price, int quantity, int watt);

    double CalculatePrice() override;
    void PrintDetails() override;

};



#endif //WEEK8_CPP_ELECTRICAL_H
