use std::collections::HashMap;

pub fn solve3a(input: Vec<&str>) -> (u32, Vec<bool>) {
    let mut overlapped_ids: Vec<bool> = vec![false; input.len()];
    let mut count: u32 = 0;
    let mut fabric_area: HashMap<(u32, u32), u32> = HashMap::new();
    let mut fabric_counted: HashMap<(u32, u32), bool> = HashMap::new();

    for i in 0..input.len() {
        let v: Vec<&str> = input[i].split(" ").collect();
        let p: Vec<&str> = v[2]
            .split(":")
            .nth(0)
            .expect("invalid idx")
            .split(",")
            .collect();
        let rect_point: (u32, u32) = (p[0].parse::<u32>().unwrap(), p[1].parse::<u32>().unwrap());
        let s: Vec<&str> = v[3].split("x").collect();
        let rect_size: (u32, u32) = (s[0].parse::<u32>().unwrap(), s[1].parse::<u32>().unwrap());

        for x in (rect_point.0)..(rect_size.0 + rect_point.0) {
            for y in (rect_point.1)..(rect_size.1 + rect_point.1) {
                let pixel: (u32, u32) = (x, y);
                if !fabric_counted.contains_key(&pixel) {
                    if fabric_area.contains_key(&pixel) {
                        count += 1;
                        fabric_counted.insert(pixel, true);
                        overlapped_ids[i] = true;
                        *overlapped_ids
                            .get_mut(*fabric_area.get(&pixel).expect("unable to get index") as usize)
                            .unwrap() = true;
                    } else {
                        fabric_area.insert(pixel, i as u32);
                    }
                } else {
                    overlapped_ids[i] = true;
                    *overlapped_ids
                        .get_mut(*fabric_area.get(&pixel).expect("unable to get index") as usize)
                        .unwrap() = true;
                }
            }
        }
    }

    return (count, overlapped_ids);
}

pub fn solve3b(overlapped_ids: Vec<bool>) -> Option<usize> {
    for i in 0..overlapped_ids.len() {
        if !overlapped_ids[i] {
            return Some(i + 1);
        }
    }
    None
}
