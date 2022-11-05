//
// Created by billy on 3/11/2022.
//

#include "Drill.h"
#include <iostream>

using namespace std;
Drill::Drill()
{
    _safetyEnabled = false;
}

Drill::Drill(const Drill& item): Device(item)
{
    this->_safetyEnabled = item._safetyEnabled;
}

Drill::~Drill()
{
    delete this;
}

Drill& Drill::operator=(const Drill &item) {
    this->_battery = item._battery;
    this->_safetyEnabled = item._safetyEnabled;

    return *this;
}



string Drill::operate() {
    if (_safetyEnabled)
    {
        return "Safety First";
    } else {
        if (Device::_battery->getConnectionStatus())
        {
            cout << "\nYour battery is now at "
            << Device::_battery->getPower()
            << " units." << endl;

            return "VRMM VRMM";
        } else {
            cout << "Await connection...\n";

            Device::_battery->connect();

            cout << "\nYour battery is now at "
             << Device::_battery->getPower()
             << " units." << endl;

            return "VRMM VRMM";
        }
    }
}