//
// Created by billy on 3/11/2022.
//

#ifndef WEEK8_CPP_SPORTS_H
#define WEEK8_CPP_SPORTS_H

#include "Product.h"
#include <iostream>
#include <string>

using namespace std;

class Sports : public Product {
private:
    string _sportType;

public:
    Sports();
    Sports(string name, double price, int quantity, string sportsType);

    double CalculatePrice() override;
    void PrintDetails() override;
};


#endif //WEEK8_CPP_SPORTS_H
