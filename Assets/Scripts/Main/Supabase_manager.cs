using Supabase;
using UnityEngine;

public class Supabase_manager : MonoBehaviour
{
    public static Supabase.Client Client { get; private set; }

    private const string SUPABASE_URL = "https://ssvutwljjcplmoimglwt.supabase.co";
    private const string SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InNzdnV0d2xqamNwbG1vaW1nbHd0Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzgzMDk4MDEsImV4cCI6MjA1Mzg4NTgwMX0.feetHKqy016jB_Boe6zhpZ-j5x7Miv9p5L1B_5b1CSc";

    async void Start()
    {
        Client = new Supabase.Client(SUPABASE_URL, SUPABASE_KEY);

        await Client.InitializeAsync();
        Debug.Log("Supabase initialized!");
    }
}
