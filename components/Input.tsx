import { View, TextInput, StyleSheet } from "react-native";
import React from "react";

interface InputProps {
  Icon: any;
  iconName: string;
  placeholder: string;
}

export default function Input({ Icon, iconName, placeholder }: InputProps) {
  return (
    <View style={[styles.input, { marginTop: 22 }]}>
      <Icon style={{ marginLeft: 16 }} name={iconName} size={24} color="gray" />
      <TextInput
        style={{
          width: 260,
          marginVertical: 10,
          marginLeft: 10,
          color: "black",
          borderRadius: 200,
        }}
        placeholder={placeholder}
      />
    </View>
  );
}
const styles = StyleSheet.create({
  img: {
    width: 150,
    height: 100,
  },
  input: {
    flexDirection: "row",
    alignItems: "center",
    paddingVertical: 5,
    backgroundColor: "#D0D0D0",
  },
});
