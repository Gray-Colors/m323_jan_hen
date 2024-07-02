#include <stdio.h>


int listsum(int list[], int size) {
    int sum = 0;
    int tmpsize = 0;
    while (tmpsize < size) {
        sum += list[tmpsize];
        tmpsize++;
    }
    return sum;
}


int main() {
    int list[5] = {1, 2, 3, 4, 5};
    int size = sizeof(list)/sizeof(int);
    printf("%d\n", size);
    printf("%d", listsum(list, size));
}