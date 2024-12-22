<template>
    <apexchart
        type="bar"
        width="100%"
        :options="chartOptions"
        :series="series"
    ></apexchart>
</template>

<script>
// import { LIMIT_LABEL } from "@/utils/constants";

export default {
    name: "ChartBarComponent",
    props: {
        // series: Array,
        // labels: Array,
    },
    data() {
        return {
            series: [
                {
                    name: "Net Profit",
                    data: [400, 430, 448, 470, 540, 580, 690, 1100, 1200, 1380],
                },
            ],
            chartOptions: {
                chart: {
                    height: 350,
                    type: "bar",
                    zoom: {
                        enabled: false,
                    },
                },
                plotOptions: {
                    bar: {
                        borderRadius: 4,
                        borderRadiusApplication: "end",
                        horizontal: true,
                    },
                },
                dataLabels: {
                    enabled: false,
                },
                xaxis: {
                    categories: [
                        "South Korea",
                        "Canada",
                        "United Kingdom",
                        "Netherlands",
                        "Italy",
                        "France",
                        "Japan",
                        "United States",
                        "China",
                        "Germany",
                    ],
                },
            },
        };
    },
};
</script>
