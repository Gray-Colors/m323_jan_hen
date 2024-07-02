#include <stdio.h>

//Eine Funktion, die aus einer Liste von Zahlen den Mittelwert aller Listenelemente berechnet.

int listsum(int list[], int size) {
    int sum = 0;
    int tmpsize = 0;
    while (tmpsize < size) {
        sum += list[tmpsize];
        tmpsize++;
    }
    return sum;
}

int avg (int list[], int size) {
    int sum = listsum(list, size);
    return sum/size;
}

int main () {
    int list[5] = {1,2,3,4,5};
    int size = sizeof(list)/sizeof(int);
    printf("%d", avg(list, size));
}