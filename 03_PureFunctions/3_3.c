#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int compare_strings(const void *a, const void *b) {
    const char **strA = (const char **)a;
    const char **strB = (const char **)b;
    return strcmp(*strA, *strB);
}

char **copy_string_array(char **arr, int count) {
    char **new_arr = malloc(count * sizeof(char *));
    for (int i = 0; i < count; ++i) {
        new_arr[i] = strdup(arr[i]);
    }
    return new_arr;
}


char** sorted(char **arr, int count) {
    char **copied_arr = copy_string_array(arr, count);
    for(int i = 0; i < count - 1; i++) {
        for (int j = 0; j < count - i - 1; j++) {
            if (compare_strings(&copied_arr[j], &copied_arr[j + 1]) > 0) {
                char* tmp = copied_arr[j];
                copied_arr[j] = copied_arr[j + 1];
                copied_arr[j + 1] = tmp;
            }
        }
    }
    return copied_arr;
}

char **sort_strings(char **arr, int count) {
    char **copied_arr = sorted(arr, count);
    return copied_arr;
}

void free_string_array(char **arr, int count) {
    for (int i = 0; i < count; ++i) {
        free(arr[i]);
    }
    free(arr);
}

int main() {
    char *input[] = {"accc", "ccca", "bbcc", "bbbb", "aaaa"};
    int count = sizeof(input) / sizeof(input[0]);
    char **sorted = sort_strings(input, count);
    for (int i = 0; i < count; ++i) {
        printf("%s\n", sorted[i]);
    }
    free_string_array(sorted, count);

    return 0;
}
