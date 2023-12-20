import { View, Text, Pressable } from "react-native";
import React from "react";

type ButtonProps = {
  title: string;
  navigated: any;
};

export default function Button({ title, navigated }: ButtonProps) {
  return (
    <View style={{ marginTop: 50 }}>
      <Pressable
        onPress={() => navigated()}
        style={{
          backgroundColor: "#FEBE10",
          width: 200,
          marginLeft: "auto",
          marginRight: "auto",
          padding: 12,
          borderRadius: 5,
        }}
      >
        <Text
          style={{
            fontWeight: "500",
            color: "white",
            textAlign: "center",
            fontSize: 18,
          }}
        >
          {title}
        </Text>
      </Pressable>
    </View>
  );
}
