class Question
{
    public static void Main(string[] args)
    {
        int[] arr = {1,4,8,10,15,30};
        int[] arr2 = {2,3,7,9,12,13};   

        int []result=Merge(arr,arr2);

        foreach(var e in result)
        {
            Console.Write(e+" ");
        }
    }

    public static int [] Merge(int[] arr, int[] arr2)
    {
        int[] result = new int[arr2.Length+arr.Length];


        int n = arr.Length; int m=arr2.Length;

        int i = 0;int j = 0;int k = 0;

        while(i<n && j<m)
        {
            Console.WriteLine("Comp" + " " + arr[i] + " " + arr2[j]);
            if (arr[i] < arr2[j])
            {
                result[k] = arr[i];
                k++;
                i++;
            }
            else
            {
                result[k] = arr2[j];
                k++;
                j++;
            }
        }
        while (i < n)
        {
            result[k] = arr[i];
            k++;
            i++;
        }
        while(j < m)
        {
            result[k] = arr2[j];
            k++;
            j++;
        }



        return result;
    }
}