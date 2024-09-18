//*****************************************************************************
//** 179. Largest Number  leetcode                                           **
//*****************************************************************************

// Custom comparator function to compare concatenated strings
int compare(const void* a, const void* b)
{
    char ab[22], ba[22];
    sprintf(ab, "%d%d", *(int*)a, *(int*)b);
    sprintf(ba, "%d%d", *(int*)b, *(int*)a);
    return strcmp(ba, ab);  // Sort in descending order
}

char* largestNumber(int* nums, int numsSize) {
    if (numsSize == 0)
        return "0";
    
    // Sort the numbers using the custom comparator
    qsort(nums, numsSize, sizeof(int), compare);
    
    // Handle the case where the largest number is 0 (e.g., [0, 0])
    if (nums[0] == 0)
        return "0";
    
    // Calculate the total length required for the result string
    int totalLength = 0;
    for (int i = 0; i < numsSize; i++)
    {
        totalLength += snprintf(NULL, 0, "%d", nums[i]);
    }

    // Allocate memory for the result string
    char* numbers = (char*)malloc(totalLength + 1);
    numbers[0] = '\0';

    // Concatenate the numbers into the result string
    for (int i = 0; i < numsSize; i++)
    {
        char buffer[12];
        sprintf(buffer, "%d", nums[i]);
        strcat(numbers, buffer);
    }

    return numbers;
}
