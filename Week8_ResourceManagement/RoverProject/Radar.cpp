//
// Created by billy on 3/11/2022.
//

#include "Radar.h"

Radar::Radar()
{

}

Radar::Radar(const Radar& item)
{

}

Radar::~Radar()
{
    delete _batteries;
    delete _devices;
}

void Radar::operator=(cosnt Rover& other)
{

}

int Radar::deviceCount()
{
    return _devices.size();
}

int Radar::batteryCount()
{
    return _batteries.size();
}

void Radar::attachDevice(Device* device)
{
    find(_devices.begin(), _devices.end(), device)
}

void Radar::attachBattery(Battery* battery)
{

}

