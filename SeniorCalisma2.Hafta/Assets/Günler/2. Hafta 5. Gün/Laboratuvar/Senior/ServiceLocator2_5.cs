using System;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

// 2. Service Locator (Tesisatçı)
// Static class olması sorun değildir çünkü durum (state) tutmaz, sadece adres defteridir.
// Service Locator
public static class ServiceLocator2_5
{
    private static readonly Dictionary<Type, IGameService2_5> services =
        new Dictionary<Type, IGameService2_5>();

    // YENİ: Yedek Servisler Listesi
    private static readonly Dictionary<Type, IGameService2_5> nullServices =
        new Dictionary<Type, IGameService2_5>();

    // ... Register ve Unregister metotları (Aynı kalacak) ...
    public static void RegisterNull<T>(T service)
        where T : IGameService2_5
    {
        var type = typeof(T);
        if (!nullServices.ContainsKey(type))
            nullServices.Add(type, service);
    }

    public static void Register<T>(T service)
        where T : IGameService2_5
    {
        var type = typeof(T);
        if (!services.ContainsKey(type))
            services.Add(type, service);
    }

    public static void Unregister<T>()
        where T : IGameService2_5
    {
        var type = typeof(T);
        if (services.ContainsKey(type))
            services.Remove(type);
    }

    // GÜNCELLENMİŞ GET METODU (Null Object Destekli)
    public static T Get<T>()
        where T : class, IGameService2_5
    {
        var type = typeof(T);

        // 1. Önce Asıl Servise Bak
        if (services.TryGetValue(type, out var service))
            return (T)service;

        // 2. Yoksa Yedek Servise Bak (Generic Çözüm)
        if (nullServices.TryGetValue(type, out var nullService))
        {
            Debug.LogWarning(
                $"[ServiceLocator] {type.Name} asıl servisi yok, Null Object dönüldü."
            );
            return (T)nullService;
        }

        // 3. Hiçbiri yoksa Hata Fırlatmak yerine "Logla ve Null Dön" (Fail Safe)
        // Bu sayede diğer servislerin hatalarını da görebilirsin.
        Debug.LogError(
            $"[ServiceLocator] CRITICAL: {type.Name} servisi ve yedeği KESİNLİKLE bulunamadı! Null dönülüyor."
        );
        return null;
    }
}
