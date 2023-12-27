import {
  View,
  Text,
  SafeAreaView,
  Image,
  StyleSheet,
  KeyboardAvoidingView,
  Pressable,
} from "react-native";
import { Entypo } from "@expo/vector-icons";
import { Feather } from "@expo/vector-icons";
import Input from "../components/Input";
import Button from "../components/Button";

export default function Login({ navigation }: any) {
  return (
    <SafeAreaView style={{ flex: 1 }}>
      {/* I wnat it centered */}
      <View style={{ flex: 1, alignItems: "center", justifyContent: "center" }}>
        <Image
          style={styles.img}
          source={require("../assets/images/amazon.png")}
        />
        <KeyboardAvoidingView>
          <Text
            style={{
              fontSize: 16,
              fontWeight: "bold",
              textAlign: "center",
            }}
          >
            Login to your account
          </Text>
          <View>
            <Input
              bgColor="#D0D0D0"
              pv={5}
              mt={22}
              Icon={Entypo}
              iconName="mail"
              placeholder="Enter your email address"
            />
            <Input
              bgColor="#D0D0D0"
              pv={5}
              mt={22}
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
            }}
          >
            <Text style={{ color: "gray", fontWeight: "500" }}>
              Keep me logged in
            </Text>
            <Text style={{ color: "#007FFF", fontWeight: "500" }}>
              Forgot password
            </Text>
          </View>

          <Button navigated={() => navigation.navigate("main")} title="Login" />

          <Pressable
            style={{ marginTop: 20 }}
            onPress={() => navigation.navigate("register")}
          >
            <Text style={{ textAlign: "center", fontWeight: "500" }}>
              Don't have an account? Register
            </Text>
          </Pressable>
        </KeyboardAvoidingView>
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
