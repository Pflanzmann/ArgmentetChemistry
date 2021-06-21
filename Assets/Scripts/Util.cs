namespace DefaultNamespace {
    public class Util {
        public static int ComparisonByHashCode<T>(T t1, T t2) {
            return t1.GetHashCode() > t2.GetHashCode() ? 1 : 0;
        }
    }
}