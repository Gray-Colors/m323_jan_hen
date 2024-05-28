// 1
let m1 = Map.ofList [("key", "value")]

// 2
let m2 = m1.Add("key2", "value2")

// 3
let m3 = m2.Add("key2", "aDifferentValue")

// 4
let m4 = m3.Remove("key")

// 5
let valueFromM3: string option = m3.TryFind("key")

// 6
let valueFromM4: string option = m3.TryFind("nonExistentKey")