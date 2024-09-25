class Utilities
{
    public static void swap(int one, int two, string[] arr){
        string temp = arr[one];
        arr[one] = arr[two];
        arr[two] = temp;
    }
}