<template>
    <apexchart
        type="line"
        width="100%"
        height="100%"
        :options="chartOptions"
        :series="series"
    ></apexchart>
</template>

<script>
export default {
    name: "ChartLineComponent",
    props: {
        title: String,
        series: Array,
        labels: Array,
    },
    data(props) {
        return {
            chartOptions: {
                chart: {
                    // height: 350,
                    type: "line",
                    zoom: {
                        enabled: false,
                    },
                },
                dataLabels: {
                    enabled: false,
                },
                stroke: {
                    curve: "straight",
                },
                title: {
                    text: props.title,
                    align: "left",
                },
                grid: {
                    row: {
                        colors: ["#f3f3f3", "transparent"], // takes an array which will be repeated on columns
                        opacity: 0.5,
                    },
                },
                xaxis: {
                    categories: props.labels,
                    title: {
                        text: "Month",
                    },
                },
            },
        };
    },
};
</script>
