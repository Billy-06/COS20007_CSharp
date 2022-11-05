//
// Created by billy on 3/11/2022.
//

#ifndef ROVERPROJECT_BATTERY_H
#define ROVERPROJECT_BATTERY_H


class Battery {
private:
    int _units;
    bool _connected;
public:
    Battery();
    Battery(const Battery& item);
    ~Battery();
    // equal sign operator
    Battery& operator=(const Battery& item);
    // less than operator to check if the battery has more charge than another
    bool operator<(const Battery& item) const;
    // greater than sign to check if a battery has greater charge than another
    bool operator>(const Battery& item) const;

    int getPower();
    bool getConnectionStatus() const;
    void connect();

};


#endif //ROVERPROJECT_BATTERY_H
