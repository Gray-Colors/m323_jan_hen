/*
Eine Funktion, die aus einer Baumstruktur mit unterschiedlich tiefer Verschachtelung alle Blätter (Elemente ohne weitere Kinder)
ausliest und in einer flachen Liste von Blättern zurückgibt.*/


#include <stdio.h>
#include <stdlib.h>
#include <time.h>

typedef struct TreeNode {
    struct TreeNode* parent;
    struct TreeNode** children;
    int numChildren;
    int value;
} TreeNode;

TreeNode* createNode(TreeNode* parent, int value) {
    TreeNode* node = (TreeNode*)malloc(sizeof(TreeNode));
    node->parent = parent;
    node->numChildren = 0;
    node->children = NULL;
    node->value = value;
    return node;
}

TreeNode* generateTree(TreeNode* parent, int depth, int numChildren) {
    if (depth == 0 || numChildren == 0) {
        return NULL;
    }

    TreeNode* node = createNode(parent, depth);

    node->numChildren = numChildren;
    node->children = (TreeNode**)malloc(numChildren * sizeof(TreeNode*));
    node->value = depth;

    for (int i = 0; i < numChildren; i++) {
        node->children[i] = generateTree(node, depth - 1, numChildren - 1);
    }

    return node;
}

void printTree(TreeNode* node) {
    if (node == NULL) return;

    printf("%d\n", node->value);

    for (int i = 0; i < node->numChildren; i++) {
        printTree(node->children[i]);
    }
}

void freeTree(TreeNode* node) {
    if (node == NULL) {
        return;
    }

    for (int i = 0; i < node->numChildren; i++) {
        freeTree(node->children[i]);
    }

    free(node->children);
    free(node);
}

int main() {
    TreeNode* root = generateTree(NULL, 4, 3);

    printTree(root);

    freeTree(root);

    return 0;
}