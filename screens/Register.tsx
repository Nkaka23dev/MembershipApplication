import {
  View,
  Text,
  SafeAreaView,
  Image,
  StyleSheet,
  Pressable,
} from "react-native";
import { Entypo, AntDesign, Feather } from "@expo/vector-icons";

import {} from "@expo/vector-icons";
import Input from "../components/Input";
import Button from "../components/Button";

export default function Register({ navigation }: any) {
  return (
    <SafeAreaView style={{ flex: 1 }}>
      {/* I wnat it centered */}
      <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
        <Image
          style={styles.img}
          source={require("../assets/images/amazon.png")}
        />
        <Text
          style={{
            fontSize: 16,
            fontWeight: "bold",
            textAlign: "center",
          }}
        >
          Create account for free
        </Text>
        <View>
          <Input
            Icon={AntDesign}
            iconName="user"
            placeholder="Enter you name"
          />
          <Input
            Icon={Entypo}
            iconName="mail"
            placeholder="Enter your email address"
          />
          <Input
            Icon={Feather}
            iconName="lock"
            placeholder="Enter your password"
          />
        </View>
        <View
          style={{
            marginTop: 15,
            flexDirection: "row",
            justifyContent: "space-between",
            width: 300,
          }}
        >
          <Text style={{ color: "gray", fontWeight: "500" }}>
            Keep me logged in
          </Text>
          <Text style={{ color: "#007FFF", fontWeight: "500" }}>
            Forgot password
          </Text>
        </View>
        <Button
          navigated={() => alert("Register button is working")}
          title="Register"
        />
        <Pressable
          style={{ marginTop: 20 }}
          onPress={() => navigation.navigate("login")}
        >
          <Text style={{ textAlign: "center", fontWeight: "500" }}>
            Don't have an account? Sign In
          </Text>
        </Pressable>
      </View>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
  img: {
    width: 150,
    height: 100,
  },
});
