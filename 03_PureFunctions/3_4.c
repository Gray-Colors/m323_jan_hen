#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct {
    char date[11];
    int priority;
    char title[100];
} Object;

int compare_dates(const void *a, const void *b) {
    const Object *oa = (const Object *)a;
    const Object *ob = (const Object *)b;
    return strcmp(oa->date, ob->date);
}

int compare_priorities(const void *a, const void *b) {
    const Object *oa = (const Object *)a;
    const Object *ob = (const Object *)b;
    return (oa->priority - ob->priority);
}

int compare_titles(const void *a, const void *b) {
    const Object *oa = (const Object *)a;
    const Object *ob = (const Object *)b;
    return strcmp(oa->title, ob->title);
}

int compare_objects(const void *a, const void *b) {
    const Object *oa = (const Object *)a;
    const Object *ob = (const Object *)b;

    int date_cmp = compare_dates(oa, ob);
    if (date_cmp != 0) return date_cmp;

    int priority_cmp = compare_priorities(oa, ob);
    if (priority_cmp != 0) return priority_cmp;

    return compare_titles(oa, ob);
}

Object* sorted_objects(Object *arr, int count) {
    Object *new_arr = malloc(count * sizeof(Object));
    if (!new_arr) {
        fprintf(stderr, "Memory allocation failed\n");
        exit(1);
    }
    memcpy(new_arr, arr, count * sizeof(Object));
    qsort(new_arr, count, sizeof(Object), compare_objects);
    return new_arr;
}

int main() {
    Object input[] = {
        {"2024-06-01", 2, "Titel B"},
        {"2024-05-01", 1, "Titel A"},
        {"2024-06-01", 1, "Titel C"},
        {"2024-05-01", 2, "Titel D"},
        {"2024-05-01", 1, "Titel E"}
    };
    int count = sizeof(input) / sizeof(input[0]);

    Object *sorted = sorted_objects(input, count);

    for (int i = 0; i < count; i++) {
        printf("Date: %s, Priority: %d, Title: %s\n", sorted[i].date, sorted[i].priority, sorted[i].title);
    }

    free(sorted);
    return 0;
}
