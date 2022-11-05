//
// Created by billy on 3/11/2022.
//

#include "Battery.h"
#include <iostream>

using namespace std;

Battery::Battery()
{
    _units = 25;
    _connected = false;
}

Battery::Battery(const Battery& item)
{
    this->_units = item._units;
    this->_connected = item._connected;

}

Battery::~Battery()
{
    delete this;
}

Battery& Battery::operator=(const Battery &item) {
    this->_units = item._units;
    this->_connected = item._connected;

    return *this;
}

bool Battery::operator<(const Battery &item) const {
    if (this->_units < item._units)
    {
        return true;
    }
    else
    {
       return false;
    }
}
bool Battery::operator>(const Battery &item) const {
    if (this->_units > item._units)
    {
        return true;
    }
    else {
        return false;
    }
}

int Battery::getPower() {
    _units -= 10;
    return _units;
}

bool Battery::getConnectionStatus() const {
    return _connected;
}

void Battery::connect()
{
    _connected = true;
    cout << "You are now connected" << endl;
}